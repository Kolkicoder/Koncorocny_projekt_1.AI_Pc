using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

    
    public class NumberToStringConverter : JsonConverter<string?>
    {
        public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {           
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    return reader.GetString();
                case JsonTokenType.Number:                    
                    using (JsonDocument numDoc = JsonDocument.ParseValue(ref reader))
                    {
                        return numDoc.RootElement.GetRawText();
                    }
                case JsonTokenType.True:
                    return "true";
                case JsonTokenType.False:
                    return "false";
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.StartObject:
                case JsonTokenType.StartArray:                   
                    using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
                    {
                        return doc.RootElement.GetRawText();
                    }
                default:                    
                    try
                    {
                        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
                        {
                            return doc.RootElement.GetRawText();
                        }
                    }
                    catch
                    {
                        return null;
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
        {
            if (value == null)
                writer.WriteNullValue();
            else
                writer.WriteStringValue(value);
        }
    }

namespace Wpf___PC_Koncorocny_projekt
{
    public class DuckDuckGoResponse
    {
        [JsonPropertyName("Abstract")] public string? Abstract { get; set; }
        [JsonPropertyName("AbstractSource")] public string? AbstractSource { get; set; }
        [JsonPropertyName("AbstractText")] public string? AbstractText { get; set; }
        [JsonPropertyName("AbstractURL")] public string? AbstractURL { get; set; }
        [JsonPropertyName("Answer")] public string? Answer { get; set; }
        [JsonPropertyName("AnswerType")] public string? AnswerType { get; set; }
        [JsonPropertyName("Definition")] public string? Definition { get; set; }
        [JsonPropertyName("DefinitionSource")] public string? DefinitionSource { get; set; }
        [JsonPropertyName("DefinitionURL")] public string? DefinitionURL { get; set; }
        [JsonPropertyName("Entity")] public string? Entity { get; set; }
        [JsonPropertyName("Heading")] public string? Heading { get; set; }
        [JsonPropertyName("Image")] public string? Image { get; set; }
        [JsonPropertyName("ImageHeight")] public JsonElement? ImageHeight { get; set; }
        [JsonPropertyName("ImageIsLogo")] public JsonElement? ImageIsLogo { get; set; }
        [JsonPropertyName("ImageWidth")] public JsonElement? ImageWidth { get; set; }
        [JsonPropertyName("Infobox")] public string? Infobox { get; set; }
        [JsonPropertyName("Redirect")] public string? Redirect { get; set; }

        [JsonPropertyName("RelatedTopics")] public List<RelatedTopic>? RelatedTopics { get; set; }
        [JsonPropertyName("Results")] public List<ResultItem>? Results { get; set; }
        [JsonPropertyName("Type")] public string? Type { get; set; }

        [JsonPropertyName("meta")] public Meta? Meta { get; set; }
    }

    public class RelatedTopic
    {
        [JsonPropertyName("Text")] public string? Text { get; set; }
        [JsonPropertyName("FirstURL")] public string? FirstURL { get; set; }
        [JsonPropertyName("Icon")] public Icon? Icon { get; set; }
        [JsonPropertyName("Topics")] public List<RelatedTopic>? Topics { get; set; }
    }

    public class ResultItem
    {
        [JsonPropertyName("Text")] public string? Text { get; set; }
        [JsonPropertyName("FirstURL")] public string? FirstURL { get; set; }
        [JsonPropertyName("Icon")] public Icon? Icon { get; set; }
    }

    public class Icon
    {
        [JsonPropertyName("URL")] public string? URL { get; set; }
        [JsonPropertyName("Height")] public JsonElement? Height { get; set; }
        [JsonPropertyName("Width")] public JsonElement? Width { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("attribution")] public JsonElement? Attribution { get; set; }
        [JsonPropertyName("blockgroup")] public JsonElement? Blockgroup { get; set; }
        [JsonPropertyName("created_date")] public string? CreatedDate { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("designer")] public JsonElement? Designer { get; set; }
        [JsonPropertyName("dev_date")] public string? DevDate { get; set; }
        [JsonPropertyName("dev_milestone")] public string? DevMilestone { get; set; }
        [JsonPropertyName("developer")] public List<Developer>? Developer { get; set; }
        [JsonPropertyName("example_query")] public string? ExampleQuery { get; set; }
        [JsonPropertyName("id")] public string? Id { get; set; }
        [JsonPropertyName("is_stackexchange")] public int? IsStackExchange { get; set; }
        [JsonPropertyName("js_callback_name")] public string? JsCallbackName { get; set; }
        [JsonPropertyName("live_date")] public JsonElement? LiveDate { get; set; }
        [JsonPropertyName("maintainer")] public Maintainer? Maintainer { get; set; }
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("perl_module")] public string? PerlModule { get; set; }
        [JsonPropertyName("producer")] public JsonElement? Producer { get; set; }
        [JsonPropertyName("production_state")] public string? ProductionState { get; set; }
        [JsonPropertyName("repo")] public string? Repo { get; set; }
        [JsonPropertyName("signal_from")] public string? SignalFrom { get; set; }
        [JsonPropertyName("src_domain")] public string? SrcDomain { get; set; }
        [JsonPropertyName("src_id")] public JsonElement? SrcId { get; set; }
        [JsonPropertyName("src_name")] public string? SrcName { get; set; }
        [JsonPropertyName("src_options")] public SrcOptions? SrcOptions { get; set; }
        [JsonPropertyName("src_url")] public string? SrcUrl { get; set; }
        [JsonPropertyName("status")] public JsonElement? Status { get; set; }
        [JsonPropertyName("tab")] public string? Tab { get; set; }
        [JsonPropertyName("topic")] public List<string>? Topic { get; set; }
        [JsonPropertyName("unsafe")] public JsonElement? Unsafe { get; set; }
    }

    public class Developer
    {
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("type")] public string? Type { get; set; }
        [JsonPropertyName("url")] public string? Url { get; set; }
    }

    public class Maintainer
    {
        [JsonPropertyName("github")] public string? Github { get; set; }
    }

    public class SrcOptions
    {
        [JsonPropertyName("directory")] public string? Directory { get; set; }
        [JsonPropertyName("is_fanon")] public int? IsFanon { get; set; }
        [JsonPropertyName("is_mediawiki")] public int? IsMediawiki { get; set; }
        [JsonPropertyName("is_wikipedia")] public int? IsWikipedia { get; set; }
        [JsonPropertyName("language")] public string? Language { get; set; }
        [JsonPropertyName("min_abstract_length")] public JsonElement? MinAbstractLength { get; set; }
        [JsonPropertyName("skip_abstract")] public int? SkipAbstract { get; set; }
        [JsonPropertyName("skip_abstract_paren")] public int? SkipAbstractParen { get; set; }
        [JsonPropertyName("skip_icon")] public int? SkipIcon { get; set; }
        [JsonPropertyName("skip_image_name")] public int? SkipImageName { get; set; }
        [JsonPropertyName("skip_qr")] public string? SkipQr { get; set; }
        [JsonPropertyName("src_info")] public string? SrcInfo { get; set; }
        [JsonPropertyName("src_skip")] public string? SrcSkip { get; set; }
    }
        
    public class SearchResult
    {
        public string Title { get; set; } = string.Empty;
        public string Snippet { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
    }
}
