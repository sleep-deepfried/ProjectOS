﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectOS.Commands
{
    internal class CommandManager
    {
        private List<Command> commands;

        public CommandManager()
        {
            commands = new List<Command>(8);
            this.commands.Add(new Help("help"));
            this.commands.Add(new ShutDown("shutdown"));
            this.commands.Add(new Restart("restart"));
            this.commands.Add(new Version("version"));
            this.commands.Add(new Clear("clear"));
            this.commands.Add(new File("file"));
            this.commands.Add(new Directory("dir"));
        }

        public String processInput(String input)
        {
            Console.WriteLine("### Input received: '" + input + "'"); // Add this line for debugging

            String[] split = input.Split(' ');

            if (split.Length < 1)
            {
                return "Invalid input. Please provide a command.";
            }

            String commandName = split[0];

            List<String> args = split.Skip(1).ToList();

            foreach (Command cmd in this.commands)
            {
                if (cmd.name == commandName)
                    return cmd.execute(args.ToArray());
            }

            return "Your command \"" + commandName + "\" does not exist";
        }

    }
}
