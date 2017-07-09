﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VBASync.Model
{
    public class VbaRepositoryFolder : VbaFolder
    {
        private readonly ISessionSettings _settings;
        private readonly ISystemOperations _so;

        public VbaRepositoryFolder(ISession session, ISessionSettings settings) : this(new RealSystemOperations(), session, settings)
        {
        }

        internal VbaRepositoryFolder(ISystemOperations so, ISession session, ISessionSettings settings) : base(so, session.FolderPath)
        {
            _settings = settings;
            _so = so;
        }

        protected override IEnumerable<string> GetModuleFilePaths() => GetModuleFilePaths(_settings.SearchRepositorySubdirectories);
    }
}