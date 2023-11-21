﻿// <copyright file="StringExtensions.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Extensions
{
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Management.Automation;

    /// <summary>
    /// Implements <see cref="string"/> extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Invoke the string as a cmd command.
        /// </summary>
        /// <param name="command">String command to be executed.</param>
        public static string InvokeAsCmd(this string command)
        {
            using var process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c {command}";
            process.Start();
            return process.StandardOutput.ReadToEnd();
        }

        /// <summary>
        /// Invoke the string as a PowerShell script.
        /// </summary>
        /// <param name="script">String to be executed.</param>
        public static Collection<PSObject> InvokeAsPowerShell(this string script)
        {
            // TODO: Who is use this method?
            using var ps = PowerShell.Create().AddScript(script);
            return ps.Invoke();
        }

        /// <summary>
        /// Converts the string to enumerated object.
        /// </summary>
        /// <typeparam name="T">Type of enumerated object.</typeparam>
        /// <param name="value">String to convert.</param>
        /// <exception cref="ArgumentOutOfRangeException">Occurs when <paramref name="value"/> is not found in enum.</exception>
        public static T ToEnum<T>(this string value)
        {
            return Enum.IsDefined(typeof(T), value)
                ? (T)Enum.Parse(typeof(T), value)
                : throw new ArgumentOutOfRangeException(paramName: value, message: $"Value: {value} is not found in {typeof(T).Name} enumeration.");
        }
    }
}
