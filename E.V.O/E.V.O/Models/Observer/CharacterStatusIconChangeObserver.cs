using E.V.O_.Models.Occupation;
using E.V.O_.ViewModels;

namespace E.V.O_.Models.Observer
{
    public class CharacterStatusIconChangeObserver : IObserver
    {
        private CharacterVM _characterVM;

        public CharacterStatusIconChangeObserver(CharacterVM character)
        {
            _characterVM = character;
        }

        public void Update(CharacterEventType eventType, object data)
        {
            if (eventType == CharacterEventType.IconChanged)
            {
                OccupationType occupationType = (OccupationType)data;
                _characterVM.Status = occupationType;
            }
        }
    }
}
