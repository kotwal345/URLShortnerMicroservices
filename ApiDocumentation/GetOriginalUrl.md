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
  "shortUrl": "project.lyPQdnQs"
}
```

### HTTP Response

#### ** Success**
```json
{
  "message": null,
  "longUrl": "https://chatgpt.com/c/67c2acbf-f0a4-8002-b136-e5399e47a01b",
  "shortUrl": "project.lyPQdnQs"
}
```