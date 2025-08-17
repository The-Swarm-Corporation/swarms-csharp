using System;
using System.Text.Json.Serialization;

namespace Swarms.Models.ReasoningAgents.ReasoningAgentCreateCompletionParamsProperties;

/// <summary>
/// The type of output format for the reasoning agent.
/// </summary>
[JsonConverter(typeof(EnumConverter<OutputType, string>))]
public sealed record class OutputType(string value) : IEnum<OutputType, string>
{
    public static readonly OutputType List = new("list");

    public static readonly OutputType Dict = new("dict");

    public static readonly OutputType Dictionary = new("dictionary");

    public static readonly OutputType String = new("string");

    public static readonly OutputType Str = new("str");

    public static readonly OutputType Final = new("final");

    public static readonly OutputType Last = new("last");

    public static readonly OutputType Json = new("json");

    public static readonly OutputType All = new("all");

    public static readonly OutputType Yaml = new("yaml");

    public static readonly OutputType Xml = new("xml");

    public static readonly OutputType DictAllExceptFirst = new("dict-all-except-first");

    public static readonly OutputType StrAllExceptFirst = new("str-all-except-first");

    public static readonly OutputType Basemodel = new("basemodel");

    public static readonly OutputType DictFinal = new("dict-final");

    public static readonly OutputType ListFinal = new("list-final");

    readonly string _value = value;

    public enum Value
    {
        List,
        Dict,
        Dictionary,
        String,
        Str,
        Final,
        Last,
        Json,
        All,
        Yaml,
        Xml,
        DictAllExceptFirst,
        StrAllExceptFirst,
        Basemodel,
        DictFinal,
        ListFinal,
    }

    public Value Known() =>
        _value switch
        {
            "list" => Value.List,
            "dict" => Value.Dict,
            "dictionary" => Value.Dictionary,
            "string" => Value.String,
            "str" => Value.Str,
            "final" => Value.Final,
            "last" => Value.Last,
            "json" => Value.Json,
            "all" => Value.All,
            "yaml" => Value.Yaml,
            "xml" => Value.Xml,
            "dict-all-except-first" => Value.DictAllExceptFirst,
            "str-all-except-first" => Value.StrAllExceptFirst,
            "basemodel" => Value.Basemodel,
            "dict-final" => Value.DictFinal,
            "list-final" => Value.ListFinal,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static OutputType FromRaw(string value)
    {
        return new(value);
    }
}
