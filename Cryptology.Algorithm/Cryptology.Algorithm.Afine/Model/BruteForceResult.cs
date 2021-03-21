namespace Criptology.Afine.Model
{
    public class BruteForceResult
    {
        #region Constructors
        public BruteForceResult()
        {
        }
        #endregion

        #region Properties
        public uint Alpha { get; set; }

        public uint Betta { get; set; }

        public string Text { get; set; }

        public string Code { get; set; }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
