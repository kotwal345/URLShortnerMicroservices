## Get Original URL

This API allows caller to get original long url, when caller provides the short url. If short URL is not present then call will receive error.

### HTTP Request 

```
POST /api/Url/getOriginalUrl
```

###### ** Request Body**
#### Scenario 1 : Valid Input'
This request will be sent for shortURL present into Database, user will receive the valid long URL.

```json
{
  "shortUrl": "project.lyxOWXda"
}
```

### HTTP Response

#### ** Success**
```json
{
    "message": null,
    "longUrl": "https://www.msn.com/en-in/news/india/trump-vance-clash-with-zelenskyy-in-heated-oval-office-exchange-over-russia-ukraine-war-read-transcript-here/ar-AA1A1NF4?ocid=msedgntp&pc=HCTS&cvid=66a926b02c2e43c9a5432c9e659ab454&ei=8",
    "shortUrl": "project.lyxOWXda"
}
```