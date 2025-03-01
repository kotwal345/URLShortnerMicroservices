## Generate Short URL

This API allows caller to generate short url, when caller provides the long url.

### HTTP Request 

```
POST /api/Url/generateShortUrl
```

###### ** Request Body**
#### Scenario 1 : Valid Input
This Request will be sent longUrl to API, and LongURL will save into database and receive shortURL from database to user.

```json
{
  "longUrl": "https://chatgpt.com/c/67c2acbf-f0a4-8002-b136-e5399e47a01b"
}
```

### HTTP Response

#### ** Success**
```json
{
  "longUrl": "https://chatgpt.com/c/67c2acbf-f0a4-8002-b136-e5399e47a01b",
  "shortUrl": "project.lyPQdnQs"
}
```