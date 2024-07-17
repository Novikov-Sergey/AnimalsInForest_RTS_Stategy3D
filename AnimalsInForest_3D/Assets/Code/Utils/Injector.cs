using System.Reflection;
 
 
namespace Utils
{
    public static class Injector   
    {
        public static T Inject<T>(AssetsStorage storage, T target) where T : class
        {
            var targetType = target.GetType();
            var fields = targetType.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var field in fields)
            {
                var injectAssetAtribute = field.GetCustomAttribute(typeof(InjectAssetAttribute)) as InjectAssetAttribute;

                if (injectAssetAtribute != null)
                {
                    var asset = storage.GetAsset(injectAssetAtribute.AssetName);
                    field.SetValue(target, asset);
                }
            }
            return (T)target;
        }
    }
}