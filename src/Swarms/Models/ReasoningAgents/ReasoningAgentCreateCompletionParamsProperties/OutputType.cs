using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Swarms.Models.ReasoningAgents.ReasoningAgentCreateCompletionParamsProperties;

/// <summary>
/// The type of output format for the reasoning agent.
/// </summary>
[JsonConverter(typeof(OutputTypeConverter))]
public enum OutputType
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

sealed class OutputTypeConverter : JsonConverter<OutputType>
{
    public override OutputType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => OutputType.List,
            "dict" => OutputType.Dict,
            "dictionary" => OutputType.Dictionary,
            "string" => OutputType.String,
            "str" => OutputType.Str,
            "final" => OutputType.Final,
            "last" => OutputType.Last,
            "json" => OutputType.Json,
            "all" => OutputType.All,
            "yaml" => OutputType.Yaml,
            "xml" => OutputType.Xml,
            "dict-all-except-first" => OutputType.DictAllExceptFirst,
            "str-all-except-first" => OutputType.StrAllExceptFirst,
            "basemodel" => OutputType.Basemodel,
            "dict-final" => OutputType.DictFinal,
            "list-final" => OutputType.ListFinal,
            _ => (OutputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputType.List => "list",
                OutputType.Dict => "dict",
                OutputType.Dictionary => "dictionary",
                OutputType.String => "string",
                OutputType.Str => "str",
                OutputType.Final => "final",
                OutputType.Last => "last",
                OutputType.Json => "json",
                OutputType.All => "all",
                OutputType.Yaml => "yaml",
                OutputType.Xml => "xml",
                OutputType.DictAllExceptFirst => "dict-all-except-first",
                OutputType.StrAllExceptFirst => "str-all-except-first",
                OutputType.Basemodel => "basemodel",
                OutputType.DictFinal => "dict-final",
                OutputType.ListFinal => "list-final",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
