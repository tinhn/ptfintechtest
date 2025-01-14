import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react-swc'

export default defineConfig({
  plugins: [react()],
  server: {
    host: true,
    port: 8000
  },
  preview: {
      host: true,
      port: 8000
  } 
})
