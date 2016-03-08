﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Create new protection policy
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmRecoveryServicesProtectionPolicy")]    
    public class NewAzureRmRecoveryServicesProtectionPolicy : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public WorkloadType WorkloadType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public BackupManagementType BackupManagementType { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesRetentionPolicyBase RetentionPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesSchedulePolicyBase SchedulePolicy { get; set; }      

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PsBackupProviderManager providerManager = new PsBackupProviderManager(new Dictionary<System.Enum, object>()
            {  
                {ContainerParams.Name, Name},             
            }, HydraAdapter);

            IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(ContainerType.AzureVM);
        }
    }
}
