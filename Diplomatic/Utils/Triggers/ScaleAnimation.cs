using Xamarin.Forms;

namespace Diplomatic.Utils.Triggers
{
    public class ScaleTriggerAction : TriggerAction<VisualElement>
    {
        public int StartsFrom { get; set; } = 0;
        public uint Duration { get; set; } = 250;

        protected override void Invoke(VisualElement visual)
        {
            var animation = new Animation(d =>
            {
                double val = StartsFrom == 0 ? d : 1 - d;
                // Scales the element 5 %
                visual.Scale = 1.0 + val / 20;
            });

            visual.Animate("scaling", animation, length: Duration, easing: Easing.SinIn);
        }
    }
}
