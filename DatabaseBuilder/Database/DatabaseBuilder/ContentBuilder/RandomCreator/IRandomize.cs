namespace DatabaseBuilder.RandomCreator
{
    /// <summary>
    /// Implements needed methods for the random data classes, e.g. Product
    /// Can be expanded.
    /// </summary>
    interface IRandomize<T>
    {
        public T Randomize();
        public bool SaveToDatabase();
    }
}
