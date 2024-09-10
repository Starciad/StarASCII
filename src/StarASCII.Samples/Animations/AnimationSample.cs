namespace StarASCII.Samples.Animations
{
    public abstract class AnimationSample
    {
        public string Name { get; protected set; }
        protected SAnimation Animation { get; set; }

        public void Play()
        {
            this.Animation.Play();
        }
    }
}
