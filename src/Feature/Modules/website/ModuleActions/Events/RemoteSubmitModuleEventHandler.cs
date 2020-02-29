using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using xTeam.Feature.Modules.ModuleUtils;
using xTeam.Feature.Modules.Module;


namespace xTeam.Feature.Modules.ModuleActions.Events
{
    public class RemoteSubmitModuleEventHandler
    {
        public void BuildModuleItem(object sender, EventArgs args)
        {
            // Get our parameter with the JSON Object
            string jsonString = Sitecore.Events.Event.ExtractParameter<string>(args, 0);
            ModuleItem moduleItem = JsonConvert.DeserializeObject<ModuleItem>(jsonString);

            // Create our module item
            if(moduleItem != null)
            {
                ModuleUtils.ModuleUtils moduleUtils = new ModuleUtils.ModuleUtils();
                moduleUtils.CreateModule(moduleItem);
            }
        }
    }
}