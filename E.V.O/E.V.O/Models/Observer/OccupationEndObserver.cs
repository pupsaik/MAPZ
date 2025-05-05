using Accessibility;
using E.V.O_.GameManaging;
using E.V.O_.Models.Buildings;
using E.V.O_.Models.Occupation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace E.V.O_.Models.Observer
{
    public class OccupationEndObserver : IObserver
    {
        private IOccupation _occupation;

        public OccupationEndObserver(IOccupation occupation)
        {
            _occupation = occupation;
        }

        public void Update(CharacterEventType type, object data)
        {
            if (type == CharacterEventType.OccupationEnded)
            {
                _occupation.TimeLeft = _occupation.Duration;
                _occupation.OccupiedCharacter.CurrentOccupation = new NoOccupation();
                if (_occupation.OccupiedCharacter.ToolInHand != null)
                {
                    _occupation.OccupiedCharacter.ToolInHand.IsOccupied = false;
                    _occupation.OccupiedCharacter.ToolInHand = null;
                }

                OccupationFacade occupationFacade = new OccupationFacade();
                occupationFacade.GetProfitFromOccupation(_occupation, _occupation.OccupiedCharacter);
                _occupation.OccupiedCharacter = null;
            }
        }
    }
}
