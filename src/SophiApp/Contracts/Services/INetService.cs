﻿// <copyright file="INetService.cs" company="Team Sophia">
// Copyright (c) Team Sophia. All rights reserved.
// </copyright>

namespace SophiApp.Contracts.Services
{
    /// <summary>
    /// A service for networking.
    /// </summary>
    public interface INetService
    {
        /// <summary>
        /// Determine if there has Internet access.
        /// </summary>
        bool IsOnline();
    }
}
