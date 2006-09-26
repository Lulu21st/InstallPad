//
// Author: Phil Crosby
//

// Copyright (C) 2006 Phil Crosby
// Permission is granted to use, copy, modify, and merge copies
// of this software for personal use. Permission is not granted
// to use or change this software for commercial use or commercial
// redistribution. Permission is not granted to use, modify or 
// distribute this software internally within a corporation.

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
namespace InstallPadTest
{
    class InstallPadTest
    {
        public static readonly string TMPDIR="";

        public static readonly string ONLINETESTPATH = "http://www.philisoft.com/projects/installpad/test/";

        /// <summary>
        /// Verify existance and size of file, in bytes.
        /// </summary>
        public static bool VerifyExistenceAndSize(string filename, long size)
        {
            if (!File.Exists(filename))
                return false;

            FileInfo info = new FileInfo(filename);
            if (info.Length != size)
            {
                Debug.WriteLine(String.Format("File size is {0}, expecting {1}", info.Length, size));
                return false;
            }

            return true;
        }

        public static string GetDownloadPath(string file)
        {
            return Path.Combine(InstallPadTest.ONLINETESTPATH, file);
        }
    }
}
