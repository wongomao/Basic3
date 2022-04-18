namespace XyzTransform;
public interface IXyzTransform
{
    public string Id { get; }
    public void TransformFile(string filename);
    public Task TransformFileAsync(string filename);
}
