using System;

namespace CVSSCalculator.MVVM.Models
{
    internal class CvssModel 
    {
        #region Constants
        private const double NetworkAttackVector = 0.85;
        private const double AdjacentAttackVector = 0.62;
        private const double LocalAttackVector = 0.55;
        private const double PhysicalAttackVector = 0.2;

        private const double LowAttackComplexity = 0.77;
        private const double HighAttackComplexity = 0.44;

        private const double NoPrivilegesRequired = 0.85;
        public double LowPrivilegesRequired;
        public double HighPrivilegesRequired;

        private const double NoUserInteraction = 0.85;
        private const double RequiredUserInteraction = 0.62;

        private const double HighConfidentiality = 0.56;
        private const double HighIntegrity = 0.56;
        private const double HighAvailability = 0.56;
        private const double LowConfidentiality = 0.22;
        private const double LowIntegrity = 0.22;
        private const double LowAvailability = 0.22;

        private const double NotDefinedExploitCodeMaturity = 1;
        private const double HighExploitCodeMaturity = 1;
        private const double FunctionalExploitCodeMaturity = 0.97;
        private const double PoCExploitCodeMaturity = 0.94;
        private const double UnprovenExploitCodeMaturity = 0.91;

        private const double NotDefinedRemediationLevel = 1;
        private const double UnavailableRemediationLevel = 1;
        private const double WorkaroundRemediationLevel = 0.97;
        private const double TemporaryRemediationLevel = 0.96;
        private const double OfficialRemediationLevel = 0.95;

        private const double NotDefinedReportConfidence = 1;
        private const double ConfirmedReportConfidence = 1;
        private const double ReasonableReportConfidence = 0.96;
        private const double UnknownReportConfidence = 0.92;
        #endregion

        #region Private Fields
        private double _baseScore;
        private double _attackVector;
        private double _attackComplexity;
        private double _privsRequired;
        private double _userInteraction;
        private double _confidentiality;
        private double _integrity;
        private double _availability;
        private bool _allBaseMetrics;
        private double _exploitCodeMaturity;
        private double _remediationLevel;
        private double _reportConfidence;
        
        #endregion

        #region Public Fields
        public string BaseScore { get; set; }
        public string AttackVector { get; set; }
        public string AttackComplexity { get; set; }
        public string PrivsRequired { get; set; }
        public string UserInteraction { get; set; }
        public string Scope { get; set; }
        public string Confidentiality { get; set; }
        public string Integrity { get; set; }
        public string Availability { get; set; }
        public string CvssString { get; set; }
        public string ExploitCodeMaturity { get; set; }
        public string RemediationLevel { get; set; }
        public string ReportConfidence { get; set; }
        #endregion

        #region Methods
        public void CalculateBaseMetrics(string attackVector, string attackComplexity, string privilegesRequired, string userInteraction, string scope, string confidentiality, string integrity, string availability, string exploitCodeMaturity, string remediationLevel, string reportConfidence)
        {

            if(String.IsNullOrEmpty(attackVector) || String.IsNullOrEmpty(attackComplexity)  || String.IsNullOrEmpty(privilegesRequired) || String.IsNullOrEmpty(userInteraction) || String.IsNullOrEmpty(scope) || String.IsNullOrEmpty(confidentiality) || String.IsNullOrEmpty(integrity) ||  String.IsNullOrEmpty(availability))
            {
                _allBaseMetrics = false;
                
            }
            else
            {
                _allBaseMetrics = true;
                if (scope == "U")
                {
                    Scope = scope;

                    if (privilegesRequired == "N")
                    {
                        _privsRequired = NoPrivilegesRequired;
                    }
                    else if (privilegesRequired == "L")
                    {
                        _privsRequired = 0.62;
                    }
                    else if (privilegesRequired == "H")
                    {
                        _privsRequired = 0.27;
                    }
                }
                else if (scope == "C")
                {
                    Scope = scope;

                    if (privilegesRequired == "N")
                    {
                        _privsRequired = NoPrivilegesRequired;
                    }
                    else if (privilegesRequired == "L")
                    {
                        _privsRequired = 0.68;
                    }
                    else if (privilegesRequired == "H")
                    {
                        _privsRequired = 0.5;
                    }
                }

                if(attackVector == "N")
                {
                    _attackVector = NetworkAttackVector;
                }
                else if(attackVector == "A")
                {
                    _attackVector = AdjacentAttackVector;
                }
                else if(attackVector == "L")
                {
                    _attackVector = LocalAttackVector;
                }
                else
                {
                    _attackVector = PhysicalAttackVector;
                }

                if(attackComplexity == "L")
                {
                    _attackComplexity = LowAttackComplexity;
                }
                else
                {
                    _attackComplexity = HighAttackComplexity;
                }

                if (userInteraction == "N")
                {
                    _userInteraction = NoUserInteraction;
                }
                else
                {
                    _userInteraction = RequiredUserInteraction;
                }

                if(confidentiality == "N")
                {
                    _confidentiality = 0;
                }
                else if(confidentiality == "L")
                {
                    _confidentiality = LowConfidentiality;
                }
                else
                {
                    _confidentiality = HighConfidentiality;
                }

                if(integrity == "N")
                {
                    _integrity = 0;
                }
                else if(integrity == "L")
                {
                    _integrity = LowIntegrity;
                }
                else
                {
                    _integrity = HighIntegrity;
                }

                if(availability == "N")
                {
                    _availability = 0;
                }
                else if(availability == "L")
                {
                    _availability = LowAvailability;
                }
                else
                {
                    _availability = HighAvailability;
                }

                if(exploitCodeMaturity == "")
                {
                    _exploitCodeMaturity = NotDefinedExploitCodeMaturity;
                    exploitCodeMaturity = "X";
                }
                else if(exploitCodeMaturity == "H")
                {
                    _exploitCodeMaturity = HighExploitCodeMaturity;
                }
                else if(exploitCodeMaturity == "F")
                {
                    _exploitCodeMaturity = FunctionalExploitCodeMaturity;
                }
                else if(exploitCodeMaturity == "P")
                {
                    _exploitCodeMaturity = PoCExploitCodeMaturity;
                }
                else if(exploitCodeMaturity == "U")
                {
                    _exploitCodeMaturity = UnprovenExploitCodeMaturity;
                }
                else
                {
                    _exploitCodeMaturity = NotDefinedExploitCodeMaturity;
                }

                if(remediationLevel == "")
                {
                    _remediationLevel = NotDefinedRemediationLevel;
                    remediationLevel = "X";
                }
                else if(remediationLevel == "U")
                {
                    _remediationLevel = UnavailableRemediationLevel;
                }
                else if(remediationLevel == "W")
                {
                    _remediationLevel = WorkaroundRemediationLevel;
                }
                else if(remediationLevel == "T")
                {
                    _remediationLevel = TemporaryRemediationLevel;
                }
                else if(remediationLevel == "O")
                {
                    _remediationLevel = OfficialRemediationLevel;
                }
                else
                {
                    _remediationLevel = NotDefinedRemediationLevel;
                }

                if(reportConfidence == "")
                {
                    reportConfidence = "X";
                    _reportConfidence = NotDefinedReportConfidence;
                }
                else if(reportConfidence == "C")
                {
                    _reportConfidence = ConfirmedReportConfidence;
                }
                else if(reportConfidence == "R")
                {
                    _reportConfidence = ReasonableReportConfidence;
                }
                else if(reportConfidence == "U")
                {
                    _reportConfidence = UnknownReportConfidence;
                }
                else
                {
                    _reportConfidence = NotDefinedReportConfidence;
                }
                
                CvssString = $"AV:{attackVector}/AC:{AttackComplexity}/PR:{privilegesRequired}/UI:{userInteraction}/S:{scope}/C:{confidentiality}/I:{integrity}/A:{availability}/E:{exploitCodeMaturity}/RL:{remediationLevel}/RC:{reportConfidence}";
            }
        }

        public double CalculateBaseScore()
        {
            if(_allBaseMetrics)
            {
                double impactSubScore = 1 - ((1 - _confidentiality) * (1 - _integrity) * (1 - _availability));
                double impact = 0;
                double temporalSubScore = _exploitCodeMaturity * _remediationLevel * _reportConfidence;

                switch (Scope)
                {
                    case "U":
                        impact = impactSubScore * 6.42;
                        break;
                    case "C":
                        impact = 7.52 * (impactSubScore - 0.029) - 3.25 * (Math.Pow(impactSubScore - 0.02, 15));
                        break;
                }


                double exploitabilty = 8.22 * _attackVector * _attackComplexity * _privsRequired * _userInteraction;

                if (impact <= 0)
                {
                    _baseScore = 0;
                }
                else
                {
                    if (Scope == "U")
                    {
                        double baseScoreUnrounded = Math.Min((exploitabilty + impact), 10);
                        //_baseScore = Math.Round((decimal)x, 1, MidpointRounding.AwayFromZero);
                        _baseScore = RoundUpOrDown((Math.Ceiling(baseScoreUnrounded * 100.00) / 100.0));
                    }
                    else
                    {
                        double baseScoreUnrounded = Math.Min((exploitabilty + impact) * 1.08, 10);
                        //_baseScore = Math.Round((decimal)x, 1, MidpointRounding.AwayFromZero);
                        _baseScore = RoundUpOrDown((Math.Ceiling(baseScoreUnrounded * 100.00) / 100.0));
                    }
                }

                return RoundUpOrDown(_baseScore * temporalSubScore);
            }
            else
            {
                return 0;
            }
        }
        private static double RoundUpOrDown(double input)
        {
            double int_input = Math.Round(input * 100000, 1, MidpointRounding.AwayFromZero);
            if (int_input % 10000 == 0)
            {
                return int_input / 100000;
            }
            else
            {
                return (Math.Floor(int_input / 10000) + 1) / 10;
            }
        }
        #endregion
    }
}
