import { initializeApp } from "firebase/app";
// Analytics is optional; remove if you don't need it
import { getAnalytics, isSupported } from "firebase/analytics";

const firebaseConfig = {
    apiKey: "AIzaSyBjtIVXc6fTKsXHydHtEAc6P6wV9s0CaIY",
    authDomain: "gasstation-3d1c9.firebaseapp.com",
    projectId: "gasstation-3d1c9",
    storageBucket: "gasstation-3d1c9.firebasestorage.app",
    messagingSenderId: "198731592843",
    appId: "1:198731592843:web:4790685d3a8ed13b6b508e",
    measurementId: "G-CRDBMQ8SZ1"
};

export const app = initializeApp(firebaseConfig);

// Analytics only if supported (prevents runtime errors in some envs)
(async () => {
    if (await isSupported()) getAnalytics(app);
})();
