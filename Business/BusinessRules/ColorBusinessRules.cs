using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class ColorBusinessRules
    {
        IColorDal _colorDal;

        public ColorBusinessRules(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void CheckIfColorNotExist(Color color)
        {
            if (color == null) throw new Exception("Color not be exist");
        }

        public void CheckIfColorExist(Color color)
        {
            if (color != null) throw new Exception("Color already exist");
        }

        public void CheckIfColorNotExist(int colorId)
        {
            Color color = _colorDal.Get(c=>c.Id==colorId);
            CheckIfColorNotExist(color);
        }

        public void CheckIfColorNameExist(string colorName)
        {
            Color color = _colorDal.Get(c => c.Name == colorName);
            CheckIfColorExist(color);
        }

    }
}
