using CVSSCalculator.Core;
using CVSSCalculator.MVVM.Models;
using System.Windows;
using System.Windows.Media;
using Visibility = System.Windows.Visibility;

namespace CVSSCalculator.MVVM.ViewModels
{
    internal class CvssViewModel : ObservableObject
    {
        #region RelayCommands
        public RelayCommand SetAttackVector { get; }
        public RelayCommand SetAttackComplexity { get; }
        public RelayCommand SetPrivileges { get; }
        public RelayCommand SetUserInteraction { get; }
        public RelayCommand SetScope { get; }
        public RelayCommand SetConfidentiality { get; }
        public RelayCommand SetIntegrity { get; }
        public RelayCommand SetAvailability { get; }
        public RelayCommand ClearScores { get; }
        public RelayCommand CopyToClipboard { get; }
        public RelayCommand SetExploitCodeMaturity { get; }
        public RelayCommand SetRemediationLevel { get; }
        public RelayCommand SetReportConfidence { get; }
        #endregion

        #region Private Fields
        private CvssModel _cvssScore;
        private SolidColorBrush _cvssColour;
        private Visibility _cvssScoreVisibility;
        #endregion

        #region Public Fields
        public Visibility CvssScoreVisibility
        {
            get { return _cvssScoreVisibility; }
            set { _cvssScoreVisibility = value; NotifyPropertyChanged(); }
        }
        public CvssModel CvssScore
        {
            get => _cvssScore;
            set { _cvssScore = value; NotifyPropertyChanged(); }
        }
        public string BaseScore
        {
            get => _cvssScore.BaseScore;
            set { _cvssScore.BaseScore = value; NotifyPropertyChanged(); }
        }
        public SolidColorBrush CvssColour
        {
            get => _cvssColour;
            set { _cvssColour = value; NotifyPropertyChanged(); }
        }
        public string AttackVector
        {
            get { return _cvssScore.AttackVector; }
            set { _cvssScore.AttackVector = value; NotifyPropertyChanged(); }
        }
        public string AttackComplexity
        {
            get { return _cvssScore.AttackComplexity; }
            set { _cvssScore.AttackComplexity = value; NotifyPropertyChanged(); }
        }
        public string UserInteraction
        {
            get { return _cvssScore.UserInteraction; }
            set { _cvssScore.UserInteraction = value; NotifyPropertyChanged(); }
        }
        public string PrivsRequired
        {
            get { return _cvssScore.PrivsRequired; }
            set { _cvssScore.PrivsRequired = value; NotifyPropertyChanged(); }
        }
        public string Scope
        {
            get { return _cvssScore.Scope; }
            set { _cvssScore.Scope = value; NotifyPropertyChanged(); }
        }
        public string Confidentiality
        {
            get { return _cvssScore.Confidentiality; }
            set { _cvssScore.Confidentiality = value; NotifyPropertyChanged(); }
        }
        public string Integrity
        {
            get { return _cvssScore.Integrity; }
            set { _cvssScore.Integrity = value; NotifyPropertyChanged(); }
        }
        public string Availability
        {
            get { return _cvssScore.Availability; }
            set { _cvssScore.Availability = value; NotifyPropertyChanged(); }
        }
        public string CvssString
        {
            get { return _cvssScore.CvssString; }
            set { _cvssScore.CvssString = value; NotifyPropertyChanged(); }
        }
        public string ExploitCodeMaturity
        {
            get { return _cvssScore.ExploitCodeMaturity; }
            set { _cvssScore.ExploitCodeMaturity = value; NotifyPropertyChanged(); }
        }
        public string RemediationLevel
        {
            get { return _cvssScore.RemediationLevel; }
            set { _cvssScore.RemediationLevel = value; NotifyPropertyChanged(); }
        }
        public string ReportConfidence
        {
            get { return _cvssScore.ReportConfidence; }
            set { _cvssScore.ReportConfidence = value; NotifyPropertyChanged(); }
        }
        #endregion
        public CvssViewModel()
        {
            CvssScore = new CvssModel();
            CvssScoreVisibility = Visibility.Hidden;
            ExploitCodeMaturity = "X";
            RemediationLevel = "X";
            ReportConfidence = "X";


            #region RelayCommand Instantiation
            SetAttackVector = new RelayCommand(param =>
            {
                AttackVector = param.ToString() ?? ""; // null coalescing operator - returns the value of the left-hand operand if it's not null
                CvssScore.CalculateBaseMetrics(AttackVector, AttackComplexity, PrivsRequired, UserInteraction, Scope, Confidentiality, Integrity, Availability, ExploitCodeMaturity, RemediationLevel, ReportConfidence);
                double score = CvssScore.CalculateBaseScore();

                SetCvssLabels(score);
            });
            SetAttackComplexity = new RelayCommand(param =>
            {
                AttackComplexity = param.ToString() ?? ""; // null coalescing operator - returns the value of the left-hand operand if it's not null
                CvssScore.CalculateBaseMetrics(AttackVector, AttackComplexity, PrivsRequired, UserInteraction, Scope, Confidentiality, Integrity, Availability, ExploitCodeMaturity, RemediationLevel, ReportConfidence);
                double score = CvssScore.CalculateBaseScore();

                SetCvssLabels(score);
            });
            SetPrivileges = new RelayCommand(param =>
            {
                PrivsRequired = param.ToString() ?? ""; // null coalescing operator - returns the value of the left-hand operand if it's not null
                CvssScore.CalculateBaseMetrics(AttackVector, AttackComplexity, PrivsRequired, UserInteraction, Scope, Confidentiality, Integrity, Availability, ExploitCodeMaturity, RemediationLevel, ReportConfidence);
                double score = CvssScore.CalculateBaseScore();

                SetCvssLabels(score);
            });
            SetUserInteraction = new RelayCommand(param =>
            {
                UserInteraction = param.ToString() ?? ""; // null coalescing operator - returns the value of the left-hand operand if it's not null
                CvssScore.CalculateBaseMetrics(AttackVector, AttackComplexity, PrivsRequired, UserInteraction, Scope, Confidentiality, Integrity, Availability, ExploitCodeMaturity, RemediationLevel, ReportConfidence);
                double score = CvssScore.CalculateBaseScore();

                SetCvssLabels(score);
            });
            SetScope = new RelayCommand(param =>
            {
                Scope = param.ToString() ?? ""; // null coalescing operator - returns the value of the left-hand operand if it's not null
                CvssScore.CalculateBaseMetrics(AttackVector, AttackComplexity, PrivsRequired, UserInteraction, Scope, Confidentiality, Integrity, Availability, ExploitCodeMaturity, RemediationLevel, ReportConfidence);
                double score = CvssScore.CalculateBaseScore();

                SetCvssLabels(score);
            });
            SetConfidentiality = new RelayCommand(param =>
            {
                Confidentiality = param.ToString() ?? ""; // null coalescing operator - returns the value of the left-hand operand if it's not null
                CvssScore.CalculateBaseMetrics(AttackVector, AttackComplexity, PrivsRequired, UserInteraction, Scope, Confidentiality, Integrity, Availability, ExploitCodeMaturity, RemediationLevel, ReportConfidence);
                double score = CvssScore.CalculateBaseScore();

                SetCvssLabels(score);
            });
            SetIntegrity = new RelayCommand(param =>
            {
                Integrity = param.ToString() ?? ""; // null coalescing operator - returns the value of the left-hand operand if it's not null
                CvssScore.CalculateBaseMetrics(AttackVector, AttackComplexity, PrivsRequired, UserInteraction, Scope, Confidentiality, Integrity, Availability, ExploitCodeMaturity, RemediationLevel, ReportConfidence);
                double score = CvssScore.CalculateBaseScore();

                SetCvssLabels(score);
            });
            SetAvailability = new RelayCommand(param =>
            {
                Availability = param.ToString() ?? ""; // null coalescing operator - returns the value of the left-hand operand if it's not null
                CvssScore.CalculateBaseMetrics(AttackVector, AttackComplexity, PrivsRequired, UserInteraction, Scope, Confidentiality, Integrity, Availability, ExploitCodeMaturity, RemediationLevel, ReportConfidence);
                double score = CvssScore.CalculateBaseScore();

                SetCvssLabels(score);
            });
            ClearScores = new RelayCommand(param =>
            {
                AttackComplexity = "";
                AttackVector = "";
                UserInteraction = "";
                PrivsRequired = "";
                Scope = "";
                Confidentiality = "";
                Integrity = "";
                Availability = "";

                CvssScore.CalculateBaseMetrics(AttackVector, AttackComplexity, PrivsRequired, UserInteraction, Scope, Confidentiality, Integrity, Availability, ExploitCodeMaturity, RemediationLevel, ReportConfidence);

                SetCvssLabels(CvssScore.CalculateBaseScore());
            });

            SetExploitCodeMaturity = new RelayCommand(param =>
            {
                ExploitCodeMaturity = param.ToString() ?? ""; // null coalescing operator - returns the value of the left-hand operand if it's not null
                CvssScore.CalculateBaseMetrics(AttackVector, AttackComplexity, PrivsRequired, UserInteraction, Scope, Confidentiality, Integrity, Availability, ExploitCodeMaturity, RemediationLevel, ReportConfidence);
                double score = CvssScore.CalculateBaseScore();

                SetCvssLabels(score);
            });

            SetRemediationLevel = new RelayCommand(param =>
            {
                RemediationLevel = param.ToString() ?? ""; // null coalescing operator - returns the value of the left-hand operand if it's not null
                CvssScore.CalculateBaseMetrics(AttackVector, AttackComplexity, PrivsRequired, UserInteraction, Scope, Confidentiality, Integrity, Availability, ExploitCodeMaturity, RemediationLevel, ReportConfidence);
                double score = CvssScore.CalculateBaseScore();

                SetCvssLabels(score);
            });

            SetReportConfidence = new RelayCommand(param =>
            {
                ReportConfidence = param.ToString() ?? ""; // null coalescing operator - returns the value of the left-hand operand if it's not null
                CvssScore.CalculateBaseMetrics(AttackVector, AttackComplexity, PrivsRequired, UserInteraction, Scope, Confidentiality, Integrity, Availability, ExploitCodeMaturity, RemediationLevel, ReportConfidence);
                double score = CvssScore.CalculateBaseScore();

                SetCvssLabels(score);
            });

            CopyToClipboard = new RelayCommand(param =>
            {
                Clipboard.SetDataObject(CvssString);
            });
            #endregion
        }

        #region Methods
        private void SetCvssLabels(double cvssScore)
        {
            //CvssColour = Brushes.LightGray;
            if(cvssScore == 0)
            {
                CvssScoreVisibility = Visibility.Hidden;
            }
            else if (cvssScore is >= 0 and <= 3.9)
            {
                CvssColour = Brushes.Green;
                CvssScoreVisibility = Visibility.Visible;
                CvssString = _cvssScore.CvssString;
            }
            else if (cvssScore is > 3.9 and <= 6.9)
            {
                CvssColour = Brushes.Orange;
                CvssScoreVisibility = Visibility.Visible;
                CvssString = _cvssScore.CvssString;
            }
            else if (cvssScore is > 6.9 and <= 8.9)
            {
                CvssColour = Brushes.Brown;
                CvssScoreVisibility = Visibility.Visible;
                CvssString = _cvssScore.CvssString;
            }
            else if (cvssScore > 8.9)
            {
                CvssColour = Brushes.Red;
                CvssScoreVisibility = Visibility.Visible;
                CvssString = _cvssScore.CvssString;
            }
            BaseScore = cvssScore.ToString("#.0");
        }
        #endregion
    }
}