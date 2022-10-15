using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class ModelBusinessRules
    {
        IModelDal _modelDal;
        public ModelBusinessRules(IModelDal modelDal)
        {
            this._modelDal = modelDal;
        }

        public void CheckIfModelExist(Model? model)
        {
            if (model == null)
            {
                throw new Exception("model not be exist");
            }
        }

        public void CheckIfModelNotExist(Model? model)
        {
            if (model != null)
            {
                throw new Exception("model already exist");
            }
        }

        public void CheckIfModelExist(int modelId)
        {
            Model? model = _modelDal.Get(b => b.Id == modelId);
            CheckIfModelExist(model);
        }

        public void CheckIfModelNameExist(string modelName)
        {
            Model? model = _modelDal.Get(b => b.Name == modelName);
            CheckIfModelNotExist(model);
        }
    }
}
