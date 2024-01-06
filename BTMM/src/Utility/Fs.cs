using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BTMM.Utility;

public static class Fs
{
    public static string ReadAllText(string path)
    {
        return File.ReadAllText(path, Encoding.UTF8);
    }

    public static bool ExistFile(string path)
    {
        return File.Exists(path);
    }

    public static void CheckFileSavePath(string path)
    {
        var folder = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
            Directory.CreateDirectory(folder);
    }

    public static void CopyFile(string src, string target, bool overwrite = true)
    {
        if (!File.Exists(src)) return;
        File.Copy(src, target, overwrite);
    }

    public static void DelFile(string path)
    {
        if (!File.Exists(path)) return;
        File.SetAttributes(path, FileAttributes.Normal);
        File.Delete(path);
    }

    public static void WriteFile(string path, string text)
    {
        var folder = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
            Directory.CreateDirectory(folder);
        File.WriteAllText(path, text, Encoding.UTF8);
    }

    public static void MakeFileReadWrite(string path)
    {
        if (!File.Exists(path)) return;
        File.SetAttributes(path, FileAttributes.Normal);
    }


    public static bool ExistDir(string path)
    {
        return Directory.Exists(path);
    }

    public static void CreateDir(string path)
    {
        if (Directory.Exists(path)) return;
        Directory.CreateDirectory(path);
    }

    public static List<string> DelDir(string path, bool captureException = false)
    {
        var errorList = new List<string>();
        if (!Directory.Exists(path)) return errorList;
        var files = Directory.GetFiles(path);
        var dirs = Directory.GetDirectories(path);
        foreach (var file in files)
        {
            try
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
            catch (Exception e)
            {
                if (captureException)
                    errorList.Add($"del file error: {file}, {e.Message}");
                else throw;
            }
        }

        foreach (var dir in dirs)
        {
            DelDir(dir, captureException);
        }

        try
        {
            Directory.Delete(path, false);
        }
        catch (Exception e)
        {
            if (captureException)
                errorList.Add($"del dir error: {path}, {e.Message}");
            else throw;
        }

        return errorList;
    }

    public static List<string> CopyDir(string srcDir, string targetDir, bool isDeleteTargetDir = true,
        bool captureException = false,
        Action<string, float>? progress = null)
    {
        var errorList = new List<string>();
        if (!Directory.Exists(srcDir)) return errorList;
        if (isDeleteTargetDir && Directory.Exists(targetDir))
        {
            try
            {
                Directory.Delete(targetDir, true);
            }
            catch (Exception e)
            {
                if (captureException)
                    errorList.Add($"del dir error: {targetDir}, {e.Message}");
                else throw;
                return errorList;
            }
        }

        if (!Directory.Exists(targetDir))
        {
            try
            {
                Directory.CreateDirectory(targetDir);
            }
            catch (Exception e)
            {
                if (captureException)
                    errorList.Add($"create dir error: {targetDir}, {e.Message}");
                else throw;
                return errorList;
            }
        }

        var files = Directory.GetFiles(srcDir);
        var folders = Directory.GetDirectories(srcDir);
        var count = files.Length;
        for (var i = 0; i < count; i++)
        {
            var file = files[i];
            try
            {
                progress?.Invoke(file, (float)i / count);
                var fileName = Path.GetFileName(file);
                var outFile = Path.Combine(targetDir, fileName);
                File.Copy(file, outFile, true);
            }
            catch (Exception e)
            {
                if (captureException)
                    errorList.Add($"copy file error: {file}, {e.Message}");
                else throw;
            }
        }

        foreach (var t in folders)
        {
            var dirInfo = new DirectoryInfo(t);
            var path = dirInfo.FullName;
            try
            {
                var outputDir = Path.Combine(targetDir, dirInfo.Name);
                var list = CopyDir(path, outputDir, isDeleteTargetDir, captureException, progress);
                errorList.AddRange(list);
            }
            catch (Exception e)
            {
                if (captureException)
                    errorList.Add($"CopyDirError:{path}:{e.Message}");
                else throw;
            }
        }

        return errorList;
    }
}
