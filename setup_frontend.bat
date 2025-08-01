@echo off
set CLIENT=client
REM === Create React app (Vite) ===
npm create vite@latest %CLIENT% -- --template react-ts
cd %CLIENT%
npm install
npm install axios @tanstack/react-query

REM === Simple env for API base URL ===
echo VITE_API_BASE=http://localhost:5000> .env.local

echo Frontend created in /client