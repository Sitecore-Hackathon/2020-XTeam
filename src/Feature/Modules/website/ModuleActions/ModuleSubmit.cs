using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Sitecore.Events;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using xTeam.Feature.Modules.Module;
using xTeam.Feature.Modules.ModuleActions.Events;
using static System.FormattableString;

namespace xTeam.Feature.Modules.ModuleActions
{
    public class ModuleSubmit : SubmitActionBase<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleSubmit"/> class.
        /// </summary>
        /// <param name="submitActionData">The submit action data.</param>
        public ModuleSubmit(ISubmitActionData submitActionData) : base(submitActionData)
        {
        }

        /// <summary>
        /// Tries to convert the specified <paramref name="value" /> to an instance of the specified target type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="target">The target object.</param>
        /// <returns>
        /// true if <paramref name="value" /> was converted successfully; otherwise, false.
        /// </returns>
        protected override bool TryParse(string value, out string target)
        {
            target = string.Empty;
            return true;
        }

        /// <summary>
        /// Executes the action with the specified <paramref name="data" />.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="formSubmitContext">The form submit context.</param>
        /// <returns>
        ///   <c>true</c> if the action is executed correctly; otherwise <c>false</c>
        /// </returns>
        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
            // Serialize our form information
            ModuleItem moduleItem = new ModuleItem(formSubmitContext);
            string jsonString = JsonConvert.SerializeObject(moduleItem);
            //var parameters = new object[] { jsonString };

            // Raise the local event
            Event.RaiseEvent("module:submit", new object[] { jsonString });

            // Add some data to the Event Queue, which will be consumed by other instances and then raised as events on those instances.
            Sitecore.Eventing.EventManager.RaiseEvent<RemoteSubmitModuleEvent>(new RemoteSubmitModuleEvent());

            Sitecore.Context.ClientPage.ClientResponse.Alert("Module Submitted.");
            
            return true;
        }
    }
}