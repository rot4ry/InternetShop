namespace DatabaseBuilder.RandomCreator
{
    /// <summary>
    /// Implements needed methods for the random data classes, e.g. Product, Client
    /// Can be expanded.
    /// </summary>
    interface IRandomize
    {
        public void Randomize();
        public bool SaveToDatabase();
    }
}
