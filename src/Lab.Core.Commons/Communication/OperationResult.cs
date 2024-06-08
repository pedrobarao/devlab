namespace Lab.Core.Commons.Communication;

public interface IOperationResult
{
    void AddError(string key, string value);

    void AddErrors(Dictionary<string, string> errors);

    void ClearErrors();

    bool HasErrors();

    Dictionary<string, string> GetErrors();
}

public interface IOperationResult<TData> : IOperationResult
{
    TData GetData();

    void SetData(TData data);
}

public class OperationResult : IOperationResult
{
    private readonly Dictionary<string, string> _errors = new();

    public void AddError(string key, string value)
    {
        _errors.Add(key, value);
    }

    public void AddErrors(Dictionary<string, string> errors)
    {
        foreach (var error in errors) _errors.Add(error.Key, error.Value);
    }

    public void ClearErrors()
    {
        _errors.Clear();
    }

    public bool HasErrors()
    {
        return _errors.Count > 0;
    }

    public Dictionary<string, string> GetErrors()

    {
        return _errors;
    }
}

public class OperationResult<TData> : OperationResult, IOperationResult<TData>
{
    private TData _data;

    public OperationResult(TData data)
    {
        _data = data;
    }

    public TData GetData()
    {
        return _data;
    }

    public void SetData(TData data)
    {
        _data = data;
    }
}