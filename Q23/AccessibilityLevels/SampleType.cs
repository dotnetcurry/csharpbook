namespace AccessibilityLevels
{
    public class SampleType
    {
        private void ClassSpecificMethod()
        {
            // visible only inside the SampleType class
        }

        protected void MethodForDerivedClasses()
        {
            // visible inside the SampleType class and any class deriving from it
        }

        internal void AssemblySpecificMethod()
        {
            // visible in its own assembly only
        }

        public void FullyVisibleMethod()
        {
            // visible everywhere
        }
    }
}
