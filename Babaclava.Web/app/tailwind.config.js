/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      transitionTimingFunction: {
        DEFAULT: 'ease-in-out'
      },
      transitionDuration: {
        DEFAULT: '600ms'
      },
      keyframes: {
        fadeIn: {
          from: {
            opacity: 1
          },
          to: {
            opacity: 0 
          }
        }
      },
      animation: {
        fade: 'fadeIn .5s ease-in-out'
      }
    },
  },
  plugins: [],
}