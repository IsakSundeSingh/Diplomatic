using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Diplomatic.Utils.Triggers
{
    public class OpacityTriggerAction : TriggerAction<VisualElement>
    {
        public int StartsFrom { set; get; } = 0;

        protected override void Invoke(VisualElement visual)
        {
            visual.Animate("label", new Animation((d) => {
                var val = StartsFrom == 0 ? d : 1 - d;
                visual.Opacity = val;
            }),
            length: 500,
            easing: Easing.Linear);
        }
    }
}
