using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzDLL
{
    public class ValTextPairEngine : IComparable
    {
        private bool _isValid = true;
        private int _begin;
        private int _end;
        private List<Tuple<int, string>> _pairs = new List<Tuple<int,string>>();
        StringBuilder _output = new StringBuilder();
        string _error = string.Empty;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
        public StringBuilder Output
        {
            get { return _output; }
            set { _output = value; }
        }
        public List<Tuple<int, string>> Pairs
        {
            get { return _pairs; }
            set { _pairs = value; }
        }
        public int End
        {
            get { return _end; }
            set { _end = value; }
        }
        public int Begin
        {
            get { return _begin; }
            set { _begin = value; }
        }
        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        public ValTextPairEngine()
        {

        }

        public static void TryCreate(string[] input, out ValTextPairEngine engine)
        {
            engine = new ValTextPairEngine();

            if (input.Length < 4)
            {
                engine._isValid = false;
                engine._error = "Must input at least 4 params in the form of begin, end, int, text.";
                return;
            }

            if (!int.TryParse(input[0], out engine._begin))
            {
                engine._isValid = false;
                engine._error = "begin param must be an integer.";
                return;
            }

            if (!int.TryParse(input[1], out engine._end))
            {
                engine._isValid = false;
                engine._error = "end param must be an integer.";
                return;
            }

            if (engine._begin >= engine._end)
            {
                engine._isValid = false;
                engine._error = "begin param must be larger than end param.";
                return;
            }

            if (!(input.Length % 2 == 0))
            {
                engine._isValid = false;
                engine._error = "incorrect number of params, after begin and end, must have val/text pairs.";
                return;
            }

            if (!engine.tryCreatePairVals(input, engine))
            {
                engine._isValid = false;
                engine._error = "val/text pairs must start with integer";
            }
        }

        private bool tryCreatePairVals(string[] input, ValTextPairEngine engine)
        {
            for (int i = 2; i < input.Length; i += 2)
            {
                    int val;
                    if (!int.TryParse(input[i], out val)) return false;

                string pairText = input[i + 1];

                engine._pairs.Add(new Tuple<int, string>(val, pairText));
            }

            return true;
        }

        public static string GetTextFromNumber(int number, List<Tuple<int, string>> pairs)
        {
            string value = string.Empty;
            foreach (var item in pairs)
            {
                if (number % item.Item1 == 0) value += item.Item2;
            }
            if (value == string.Empty) value = number.ToString();

            return value;
        }

        #region IComparable code

        public override bool Equals(Object obj)
        {
            return (this.CompareTo(obj) == 0);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            FizzBuzzDLL.ValTextPairEngine engine = obj as ValTextPairEngine;
            if (engine == null) return 1;

            if (this._begin != engine._begin || this._end != engine._end || this._error != engine._error
                || this._isValid != engine._isValid || this._output.ToString() != engine._output.ToString())
                return 1;

            if (this._pairs.Count != engine._pairs.Count) return -1;

            for (int i = 0; i < _pairs.Count; i++)
            {
                if (this._pairs[i].Item1 != engine._pairs[i].Item1 || this._pairs[i].Item2 != engine._pairs[i].Item2)
                    return 1;
            }

            return 0;
        }

        #endregion
    }
}
