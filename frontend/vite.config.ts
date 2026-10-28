/// <reference types="vitest/config" />
import react from '@vitejs/plugin-react'
import { defineConfig } from 'vite'
import { VitePWA } from 'vite-plugin-pwa'

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    react(),
    VitePWA({
      registerType: 'autoUpdate',
      includeAssets: ['favicon.svg'],
      manifest: {
        name: 'Loyalty Platform',
        short_name: 'Loyalty',
        description: 'Loyalty platform prototype (scaffold)',
        start_url: '/',
        display: 'standalone',
        theme_color: '#1f2937',
        background_color: '#ffffff',
        icons: [
          { src: 'favicon.svg', sizes: 'any', type: 'image/svg+xml', purpose: 'any' },
        ],
      },
    }),
  ],
  server: {
    // Forward backend calls during local development (backend: dotnet run, port 5206).
    proxy: {
      '/health': 'http://localhost:5206',
    },
  },
  test: {
    environment: 'jsdom',
    setupFiles: ['./src/test-setup.ts'],
  },
})
