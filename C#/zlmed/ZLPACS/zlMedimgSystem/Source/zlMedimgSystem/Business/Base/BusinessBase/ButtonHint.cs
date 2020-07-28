using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.BusinessBase
{
    public class ButtonHint
    {
        public delegate void EventFinish(Control butState);

        public event EventFinish OnFinish;

        private Control _button = null;
        private Timer _timer = null;

        private string _sourceText = "";
        private Color _sourceColor;
        private string _stateText = "";

        private bool _isRuning = false;

        private int _count = 0;


        public bool Runing
        {
            get { return _isRuning; }
        }
        
        public ButtonHint(Control butState, string stateText)
        {
            _button = butState;
            _timer = new Timer();

            _stateText = stateText;
            _sourceText = butState.Text;
            _sourceColor = butState.BackColor;

            _timer.Enabled = false;

            _timer.Interval = 100;
            _timer.Tick += timer1_Tick; 
        }

        public void Start()
        {
            if (_isRuning) return;

            _isRuning = true;
            _timer.Enabled = true;
        }

        static private List<Control> _butStates = null;

        static public void Start(Control butState, string stateText)
        {
            if (_butStates == null) _butStates = new List<Control>();

            lock (_butStates)
            {
                int butIndex = _butStates.FindIndex(T => T.Name == butState.Name);

                if (butIndex >= 0) return;

                _butStates.Add(butState);

                ButtonHint bh = new ButtonHint(butState, stateText);
                bh.OnFinish += Finish;
                bh.Start();
            }
        }

        static private void Finish(Control butState)
        {
            lock(_butStates)
            {
                _butStates.Remove(butState);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                if (_count == 0)
                {
                    _count = 1;
                    _button.Text = _stateText;

                    _button.BackColor = Color.Lime;
                    Application.DoEvents();
                }
                else
                {
                    if (_count == 1)
                    {
                        _count = 2;

                        _button.Text = "  " + _stateText;
                        Application.DoEvents();
                    }
                    else
                    {
                        if (_count == 2)
                        {
                            _count = 3;

                            _button.Text = _stateText + "  ";
                            Application.DoEvents();
                        }
                        else
                        {
                            _timer.Enabled = false;
                            _count = 0;

                            _button.Text = _sourceText;
                            _button.BackColor = _sourceColor;

                            OnFinish?.Invoke(_button);

                            _button = null;
                            _isRuning = false;
                        }
                    }


                }
            }
            catch
            {
                _count = 0;
                _timer.Enabled = false;

                OnFinish?.Invoke(_button);

                _button = null;
                _isRuning = false;
            }
        }

    }
}
