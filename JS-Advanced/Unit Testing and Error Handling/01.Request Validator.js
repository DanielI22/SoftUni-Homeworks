function solve(object) {

    let method = object.method;
    if(method !== 'GET'
    && method !== 'POST'
    && method !== 'DELETE'
    && method !== 'CONNECT') {
        throw new Error("Invalid request header: Invalid Method")
    }

    let uri = object.uri;
    if(typeof(uri) == 'undefined') {
        throw new Error("Invalid request header: Invalid URI")
    }
    if(uri !== '*' && !uri.match(/^[\w.]+$/g)) {
        throw new Error("Invalid request header: Invalid URI")
    }
    
    let version = object.version;
    if(version !== 'HTTP/0.9'
    && version !== 'HTTP/1.0'
    && version !== 'HTTP/1.1'
    && version !== 'HTTP/2.0') {
        throw new Error("Invalid request header: Invalid Version")
    }

    let message = object.message;
    let specialChr = ['<', '>', '\\', '&', '\'', '"'];
    if(typeof(message) == 'undefined') {
        throw new Error("Invalid request header: Invalid Message")
    }
    for(let ch of message) {
        if(specialChr.includes(ch)) {
            throw new Error("Invalid request header: Invalid Message")
        }
    }

    return object;
}

solve({
    method: 'GET',
    uri: '*',
    version: 'HTTP/1.1',
    message: 'dsa'
  }
  
)