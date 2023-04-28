<h1 align="center" style="border-bottom: none;">🔑 dotnet-jwtil</h1>
<div align="center">
    <a href="https://github.com/prestonvtonder/dotnet-jwtil/actions?query=workflow%3Arelease+branch%3Amain">
        <img alt="Build Status" src="https://github.com/prestonvtonder/dotnet-jwtil/actions/workflows/release.yml/badge.svg">
    </a>
    <a href="#badge">
        <img alt="semantic-release: angular" src="https://img.shields.io/badge/semantic--release-angular-e10079?logo=semantic-release">
    </a>
</div>
<h3 align="center">A command-line tool for inspecting JWTs</h3>

## Installation

### Linxux / MacOS

Determine the .NET Runtime Identifier for your machine based on the [catalog](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog) and replace `<rid>` accordingly.

```
curl -L https://github.com/prestonvtonder/dotnet-jwtil/releases/download/latest/<rid>.tar.gz > jwtil.tar.gz
```

Extract the contents to `/usr/local/bin`.

```
tar -xvf jwtil.tar.gz -C /usr/local/bin
```

## Usage

```
USAGE:
    jwtil <token> [OPTIONS]

ARGUMENTS:
    <token>    The JSON Web Token

OPTIONS:
    -h, --help    Prints help information

COMMANDS:
    decode <token>    Decode a JSON Web Token
```

### Example

```
jwtil eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
```

#### Output
```
╭─Header 👎──────────╮
│ {                  │
│    "alg": "HS256", │
│    "typ": "JWT"    │
│ }                  │
╰────────────────────╯
╭─Payload 👎──────────────╮
│ {                       │
│    "sub": "1234567890", │
│    "name": "John Doe",  │
│    "iat": 1516239022    │
│ }                       │
╰─────────────────────────╯
```
