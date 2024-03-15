using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediumSite.Application.Abstractions.Mapper
{
    public static class MapperPro
    {
        public static TEntity ManualMapper<TEntity>(this object entity)
           where TEntity : class
        {
            var EntityPro = Activator.CreateInstance<TEntity>();
            var TypeOfEntityPro = EntityPro.GetType();
            var TypeOfObjectPro = entity.GetType();

            PropertyInfo[] PropertyPros = TypeOfEntityPro.GetProperties();

            foreach (var PropertyPro in PropertyPros)
            {
                var ObjectOfPropertyPro = TypeOfObjectPro.GetProperty(PropertyPro.Name);

                if (ObjectOfPropertyPro != null)
                    PropertyPro.SetValue(EntityPro, ObjectOfPropertyPro.GetValue(entity));
            }
            //Ustoz aytganingizdek 0 dan yozdim!
            return (TEntity)EntityPro;
        }
    }
}



    //    public static TEntity ManualMapper<TEntity>(this object entity)
    //        where TEntity : class, new()
    //    {
    //        var result = new TEntity();
    //        var entityType = typeof(TEntity);

    //        foreach (var entityProperty in entityType.GetProperties())
    //        {
    //            var sourceProperty = entity.GetType().GetProperty(entityProperty.Name);
    //            if (sourceProperty != null && sourceProperty.CanRead && entityProperty.CanWrite)
    //            {
    //                var sourceValue = sourceProperty.GetValue(entity);
    //                entityProperty.SetValue(result, sourceValue);
    //            }
    //        }

    //        return result;
    //    }
    //Ustoz Googledan qidirib ko'rgandim boshqacha yo'li ham bor ekan!