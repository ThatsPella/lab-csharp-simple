namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        private string[] seeds;

        private string[] names;

        // TODO improve
        public IList<string> Seeds
        { 
            get => this.seeds.ToList() ;
            set => this.seeds = value.ToArray();
        }

        // TODO improve
        public IList<string> Names
        {
            get => this.names.ToList();
            set => this.names = value.ToArray();
        }

        // TODO improve
        public int DeckSize() => this.names.Length * this.seeds.Length;

        /// TODO improve
        public ISet<Card> Deck
        {
            get
            { 
                if (this.names == null || this.seeds == null)
                {
                    throw new InvalidOperationException();
                }

                return new HashSet<Card>(Enumerable
                    .Range(0, this.names.Length)
                    .SelectMany(i => Enumerable
                        .Repeat(i, this.seeds.Length)
                        .Zip(
                            Enumerable.Range(0, this.seeds.Length),
                            (n, s) => Tuple.Create(this.names[n], this.seeds[s], n)))
                    .Select(tuple => new Card(tuple))
                    .ToList());
            }
        }
    }
}
