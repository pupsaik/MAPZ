using E.V.O_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E.V.O_.GameManaging
{
    public class TimeManager
    {
        private CharacterManager _characterManager;

        public int DayCounter { get; set; }
        public event Action? DayCounterChanged;

        public TimeManager(CharacterManager characterManager)
        {
            DayCounter = 1;
            _characterManager = characterManager;
        }

        public void SkipToNextDay()
        {
            DayCounter++;
            DayCounterChanged?.Invoke();

            foreach (var character in _characterManager.GetCharacters())
            {
                character.SkipToNextDay();
            }
        }
    }
}
