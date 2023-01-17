using SourceBuilder.Builders.Abstract;
using SourceBuilder.Helpers;
using SourceBuilder.Models;

namespace SourceBuilder.Builders;

public class ServiceBuilder : IBuilder
{
    public void Build(List<Entity> entities)
    {
        entities.ForEach(model =>
        {
            var text = TextBuilder.BuildTextForEntityService(model);
            Workers.SourceBuilder.Instance.AddSourceFile(Constants.ServicePath, $"{model.Name}Service.cs", text);
        });
    }
}