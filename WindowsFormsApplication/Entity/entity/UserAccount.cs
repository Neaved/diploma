﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;
using log4net.Config;

namespace Entity.entity
{
    public class UserAccount : WithSidEntity
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private string fullName;
        private HashSet<string> groupNames;
        private string description;

        public UserAccount(string name, string sid, HashSet<string> groupNames, string description) : base(name, sid)
        {
            XmlConfigurator.Configure();
            setFullName(name);
            this.groupNames = groupNames;
            this.description = description;
        }

        public UserAccount(string name, string sid, HashSet<string> groupNames) : base(name, sid)
        {
            this.groupNames = groupNames;
        }

        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }
        public HashSet<string> GroupNames
        {
            get
            {
                return groupNames;
            }

            set
            {
                groupNames = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string GroupNamesInString()
        {
            if (GroupNames.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string groupName in GroupNames)
                {
                    sb.Append(groupName + ", ");
                }
                string groupNames = sb.ToString();
                return groupNames.Substring(0, groupNames.Length - 2);
            }
            else
            {
                return string.Empty;
            }
        }

        private void setFullName(string name)
        {
            if (name.Contains("|"))
            {
                string[] namePart = name.Split('|');
                Name = namePart[0].Trim();
                FullName = name.Replace("|", " (") + ")";
            }
            else
            {
                FullName = Name;
            }
        }

        public override string ToString()
        {
            return Name + "; " + Sid + ";";
        }

    }
}