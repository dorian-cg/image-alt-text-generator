# Image Alt Text Generator
Image alternative text generator, uses C# .NET 8 with [Semantic Kernel](https://learn.microsoft.com/en-us/semantic-kernel/overview) along with Open AI's [o4-mini](https://openai.com/index/introducing-o3-and-o4-mini/) model for the backend and [Next](https://nextjs.org) with [Chakra UI](https://chakra-ui.com) for the frontend.

## Installation setup

### 1. Install software
1. [Git](https://git-scm.com/)
2. [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
3. [NodeJS 22](https://nodejs.org/en/download)
4. [VS Code (recommended for working with TypeScript and Next)](https://code.visualstudio.com/)
5. [Visual Studio (recommended for working with C#)](https://visualstudio.microsoft.com/)


### 2. Clone the repository
```bash
git clone https://github.com/dorian-cg/image-alt-text-generator.git
```

### 3. Install npm dependencies
```bash
cd ./image-alt-text-generator/src/web
npm install
```

### 4. Update appsettings.json
```bash
# open appsettings.json with VS Code
code ./image-alt-text-generator/src/api/appsettings.json
```

```jsonc
// appsettings.json
{
  "AzureOpenAIChatCompletion": {
    "DeploymentName": "o4-mini",    
    "ApiKey": "<YOUR_API_KEY>", // replace <YOUR_API_KEY> with your own key
    "Endpoint": "https://<YOUR_SERVICE_NAME>.openai.azure.com" // replace <YOUR_SERVICE_NAME> with your own service name
  }
}
```

## Running the project
1. Open `/image-alt-text-generator/src/api/ImageAltTextService.sln` using Visual Studio.
2. Wait for NuGet packages to restore.
3. Run using `https` profile using play button at the top.
4. Open a terminal.
5. Change to `src/web` directory using `cd /image-alt-text-generator/src/web`
6. Start frontend project using `npm run dev`.
7. Open browser at `http://localhost:3000`

## Demo screenshots

### Default look of the app.

<img src="https://raw.githubusercontent.com/dorian-cg/image-alt-text-generator/refs/heads/main/docs/screenshots/app_screenshot.png" height="360px">

### After adding images.

<img src="https://raw.githubusercontent.com/dorian-cg/image-alt-text-generator/refs/heads/main/docs/screenshots/app_screenshot_with_images_added.png" height="360px">


### Generation Examples

#### 1. Camera image from Unsplash

##### Original image
<img src="https://raw.githubusercontent.com/dorian-cg/image-alt-text-generator/refs/heads/main/docs/unsplash-samples/camera.jpg" height="320px">

##### Generated result
<img src="https://raw.githubusercontent.com/dorian-cg/image-alt-text-generator/refs/heads/main/docs/screenshots/camera_generated.png" width="720px">

#### 2. Cup image from Unsplash

##### Original image
<img src="https://raw.githubusercontent.com/dorian-cg/image-alt-text-generator/refs/heads/main/docs/unsplash-samples/cup.jpg" height="320px">

##### Generated result
<img src="https://raw.githubusercontent.com/dorian-cg/image-alt-text-generator/refs/heads/main/docs/screenshots/cup_generated.png" width="720px">

#### 3. House image from Unsplash

##### Original image
<img src="https://raw.githubusercontent.com/dorian-cg/image-alt-text-generator/refs/heads/main/docs/unsplash-samples/house.jpg" height="320px">

##### Generated result
<img src="https://raw.githubusercontent.com/dorian-cg/image-alt-text-generator/refs/heads/main/docs/screenshots/house_genearted.png" width="720px">

#### 4. Pizza image from Unsplash

##### Original image
<img src="https://raw.githubusercontent.com/dorian-cg/image-alt-text-generator/refs/heads/main/docs/unsplash-samples/pizza.jpg" height="320px">

##### Generated result
<img src="https://raw.githubusercontent.com/dorian-cg/image-alt-text-generator/refs/heads/main/docs/screenshots/pizza_generated.png" width="720px">
