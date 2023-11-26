﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOS.Commands{
    public class Command{
        
        public readonly string name;

        public static SysInfo info;
        
        public Command(string name)
        {
            this.name = name;
        }

        public virtual String execute(String[] args)
        {
            return "Command not found";
        }
    }

    internal class Help : Command
    {

        public Help(String name) : base(name) { }

        public override String execute(String[] args)
        {
            return @"
            clear       To clear the text
            restart     To reboot
            shutdown    To turn off the system
            version     To show the current verion
            
            file        file manamgement
            input: file + command

            command:
            mkfile      make file 
            mkdir       make directory
            rmfile      remove file
            rmdir       remove directory
            writestr    write in a text file
            readstr     read text file
            space       read remaining space
            lsdir       list of directories
            lsfile      list of files in the directory";

        }
    }

    internal class Clear : Command
    {
        public Clear(String name) : base(name) { }

        public override String execute(String[] args)
        {
            Console.Clear();
            return "Welcome to ProjectOS\nType \"help\" for basic commands";
        }
    }

    internal class Restart : Command
    {
        public Restart(String name) : base(name) { }

        public override String execute(String[] args)
        {
            String response = "Restarting the system...";
            Console.WriteLine(response);
            Cosmos.System.Power.Reboot();
            return "Welcome to ProjectOS\nType \"help\" for basic commands";
        }
    }

    internal class ShutDown : Command
    {
        public ShutDown(String name) : base(name) { }

        public override String execute(String[] args)
        {
            Cosmos.System.Power.Shutdown();
            return "Shutting down the system...";
        }
    }

    internal class Version : Command
    {
        public Version(String name) : base(name) { }
        public override String execute(String[] args)
        {
            return "ProjectOS v1.0.0";
        }
    }

    internal class getSysInfo : Command
    {
        public getSysInfo (String name) : base(name) { }

        public override string execute(string[] args)
        {
            Command.info = new SysInfo();
            return "System Info Generated";
        }
    }
}
