using System;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace TaskForCopyFilesBeforeBuild
{
    public class TaskForCopyFiles : Task
    {
        private string sourceDir;// = "C:\\From";
        private string targetDir;// = "C:\\To";

        //[Required]
        public string SourceDir
        {
            get
            {
                return sourceDir;
            }
            set
            {
                sourceDir = value;
            }
        }

        //[Required]
        public string TargetDir
        {
            get
            {
                return targetDir;
            }
            set
            {
                targetDir = value;
            }
        }
        public override bool Execute()
        {

            Copy(sourceDir, targetDir);
            return true;
        }

        void Copy(string source, string target)
        {
            Directory.CreateDirectory(target);

            foreach (var file in Directory.GetFiles(source))
                File.Copy(file, Path.Combine(target, Path.GetFileName(file)));

            foreach (var directory in Directory.GetDirectories(source))
                Copy(directory, Path.Combine(target, Path.GetFileName(directory)));
        }

}
}
