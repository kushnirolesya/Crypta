using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using Cryptology.Caesar.Algorithm;
using Cryptology.Core;

namespace Cryptology.UI
{
    internal class CaesarViewModel : ViewModelBase
    {
        private int shift;
        private string inputText;
        private string outputText;
        private string actionText;
        private bool isEncode;
        private bool isAnalyzingCompleted;
        private Visibility analyzeButtonVisibility;
        private Visibility detailsButtonVisibility;

        #region Constructor
        public CaesarViewModel()
        {
            Algorithm = new CaesarAlgorithm();
            Analyzer = new CaesarFrequencyAnalyzer();
            IsEncode = true;
            Shift = default;
            TextAnalyzingPerformed = false;
            IsAnalyzingCompleted = false;
            DetailsButtonVisibility = Visibility.Collapsed;
        }
        #endregion

        #region Properties
        public CaesarAlgorithm Algorithm { get; }

        public CaesarFrequencyAnalyzer Analyzer { get; set; }

        public bool TextAnalyzingPerformed { get; set; }

        public bool IsAnalyzingCompleted
        {
            get
            {
                return isAnalyzingCompleted;
            }
            set
            {
                if (isAnalyzingCompleted != value)
                {
                    isAnalyzingCompleted = value;
                    OnProtertyChanged();

                    if (isAnalyzingCompleted)
                    {
                        DetailsButtonVisibility = Visibility.Visible;
                    }
                    else
                    {
                        DetailsButtonVisibility = Visibility.Collapsed;
                    }
                }
            }
        }

        public Visibility DetailsButtonVisibility
        {
            get
            {
                return detailsButtonVisibility;
            }
            set
            {
                if (detailsButtonVisibility != value)
                {
                    detailsButtonVisibility = value;
                    OnProtertyChanged();
                }
            }
        }

        public Visibility AnalyzeButtonVisibility
        {
            get
            {
                return analyzeButtonVisibility;
            }
            set
            {
                if (analyzeButtonVisibility != value)
                {
                    analyzeButtonVisibility = value;
                    OnProtertyChanged();
                }
            }
        }

        public string ActionText
        {
            get
            {
                return actionText;
            }

            set
            {
                if (actionText != value)
                {
                    actionText = value;
                    OnProtertyChanged();
                }
            }
        }

        public bool IsEncode
        {
            get
            {
                return isEncode;
            }

            set
            {
                if (isEncode != value)
                {
                    isEncode = value;
                    OnProtertyChanged();
                    if (isEncode)
                    {
                        ActionText = "Encode";
                        AnalyzeButtonVisibility = Visibility.Collapsed;
                    }
                    else
                    {
                        ActionText = "Decode";
                        AnalyzeButtonVisibility = Visibility.Visible;
                    }
                }
            }
        }

        public int Shift
        {
            get
            {
                return shift;
            }
            set
            {
                if (shift != value)
                {
                    shift = value;
                    Algorithm.Shift = value;
                    OnProtertyChanged();
                }
            }
        }

        public string InputText
        {
            get
            {
                return inputText;
            }
            set
            {
                if (inputText != value)
                {
                    inputText = value;
                    OnProtertyChanged();
                }
            }
        }

        public string OutputText
        {
            get
            {
                return outputText;
            }
            set
            {
                if (outputText != value)
                {
                    outputText = value;
                    OnProtertyChanged();
                }
            }
        }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Process()
        {
            if (IsEncode)
            {
                OutputText = Algorithm.Encode(InputText);
            }
            else
            {
                OutputText = Algorithm.Decode(InputText);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Analyze()
        {
            try
            {
                if (TextAnalyzingPerformed == false)
                {
                    using (var reader = new StreamReader(GlobalConstants.TextFilePath, Algorithm.Encoding))
                    {
                        var text = reader.ReadToEnd();
                        Analyzer.AnalyzeText(text);
                    }

                    TextAnalyzingPerformed = true;
                }

                Analyzer.AnalyzeCryptoText(InputText);
                IsAnalyzingCompleted = true;

                OutputText = Analyzer.TryEncode(InputText);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
