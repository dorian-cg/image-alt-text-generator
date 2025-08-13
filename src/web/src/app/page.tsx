"use client";

import { Alert, Box, Button, Card, Container, Flex, Heading, Image, Spinner } from "@chakra-ui/react"
import { useCallback, useState } from 'react';
import { ImageUploader } from './components/ImageUploader';

type GenerateAltTextResponse = {
  imagesAltTextGenerated: Record<string, string>;
}

const endpoint = "https://localhost:7158/api/v1/image-alt-text/generate";

export default function Home() {
  const [images, setImages] = useState<File[]>([]);
  const [isGenerating, setIsGenerating] = useState(false);
  const [generationError, setGenerationError] = useState<Error | null>(null);
  const [altTextGenerated, setAltTextGenerated] = useState<Record<string, string> | null>(null);

  const onGenerateClick = useCallback(async () => {
    setIsGenerating(true);
    setGenerationError(null);
    setAltTextGenerated(null);

    if (images.length === 0) {
      setGenerationError(new Error("Please upload at least one image file."));
      setIsGenerating(false);
      return;
    }

    try {
      const form = new FormData();

      for (const img of images) {
        form.append("Images", new Blob([img]), img.name);
      }

      const response = await fetch(endpoint, {
        method: "POST",
        body: form,
      });

      const data = await response.json() as GenerateAltTextResponse;
      setAltTextGenerated(data.imagesAltTextGenerated);

    } catch (error) {
      setGenerationError(error as Error);
    } finally {
      setIsGenerating(false);
    }
  }, [images]);

  return (
    <Flex
      direction="column"
      align="center"
      justify="center">
      <Heading as="h1" size="6xl" mt="16" mb="16">🖼️ Image Alt Text Service</Heading>
      <ImageUploader onFilesChange={setImages} disabled={isGenerating} />
      <Button mb="16" disabled={isGenerating} onClick={onGenerateClick}>{isGenerating ? "Generating" : "Generate"}</Button>
      {isGenerating && (
        <Box>
          <Spinner size="xl" />
        </Box>
      )}
      {generationError && (
        <Alert.Root mb="16" status="error">
          <Alert.Indicator />
          <Alert.Content>
            <Alert.Title>Error Generating</Alert.Title>
            <Alert.Description>
              {generationError.message}
            </Alert.Description>
          </Alert.Content>
        </Alert.Root>
      )}
      {altTextGenerated && (
        Object.keys(altTextGenerated).map((fileName) => (
          <Card.Root mb="16" flexDirection="row" overflow="hidden" maxW="xl" key={fileName}>
            <Image
              objectFit="cover"
              maxW="200px"
              src={images.find(f => f.name === fileName) ? URL.createObjectURL(images.find(f => f.name === fileName)!) : undefined}
              alt={altTextGenerated[fileName]}
            />
            <Box>
              <Card.Body>
                <Card.Title mb="2">{fileName}</Card.Title>
                <Card.Description>
                  {altTextGenerated[fileName]}
                </Card.Description>
              </Card.Body>
            </Box>
          </Card.Root>
        )))}
    </Flex>
  );
}
