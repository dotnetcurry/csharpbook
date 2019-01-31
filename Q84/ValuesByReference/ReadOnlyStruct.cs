namespace ValuesByReference
{
    readonly struct ReadonlyStruct
    {
        public int ImmutableProperty { get; }
        //public int MutableProperty { get; set; } // will not compile
    }
}
