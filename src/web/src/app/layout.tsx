import { Provider } from '@/components/ui/provider';
import type { Metadata } from "next";
import { PropsWithChildren } from 'react';

export const metadata: Metadata = {
  title: "Image Alt Text Generator",
  description: "Generate alternative text for images using AI",
};

export default function RootLayout({ children }: PropsWithChildren) {
  return (
    <html lang="en" suppressHydrationWarning>
      <body>
        <Provider>
          {children}
        </Provider>
      </body>
    </html>
  );
}
