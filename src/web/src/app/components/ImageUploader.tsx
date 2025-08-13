import { Box, FileUpload, Icon, useFileUpload } from "@chakra-ui/react"
import { LuUpload } from "react-icons/lu"

type ImageUploderProps = {
  onFilesChange: (files: File[]) => void;
  disabled?: boolean;
}

export function ImageUploader({ onFilesChange, disabled }: ImageUploderProps) {
  return (
    <FileUpload.Root
      disabled={disabled}
      mb={8}
      maxW="xl"
      alignItems="stretch"
      accept={["image/jpeg", "image/png"]}
      maxFileSize={5 * 1024 * 1024}
      maxFiles={8}
      onFileChange={(files) => onFilesChange(files.acceptedFiles)}>
      <FileUpload.HiddenInput />
      <FileUpload.Dropzone>
        <Icon size="md" color="fg.muted">
          <LuUpload />
        </Icon>
        <FileUpload.DropzoneContent>
          <Box>Drag and drop files here</Box>
          <Box color="fg.muted">.png, .jpg up to 5MB</Box>
        </FileUpload.DropzoneContent>
      </FileUpload.Dropzone>
      <FileUpload.List />
    </FileUpload.Root>
  );
}
