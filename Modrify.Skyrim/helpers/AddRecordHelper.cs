using Mutagen.Bethesda.Skyrim;

namespace Modrify.Skyrim
{
    public static partial class Helpers
    {
        public static void AddRecordHelper(ISkyrimMod mod, ISkyrimMajorRecordGetter record)
        {
            var recordType = record.GetType();
            var recordTypeName = recordType.Name.Replace("BinaryOverlay", "");

            var modType = mod.GetType();
            var property = modType.GetProperty(recordTypeName + "s");

            if (property != null)
            {
                var list = property.GetValue(mod);
                var method = list.GetType().GetMethod("Add");

                if (method != null)
                {
                    method.Invoke(list, new object[] { record });
                }
            }
        }
    }
}
