(() => {
  let audioContext;
  let previousFocus;
  const keyHandlers = new WeakMap();
  const reducedMotion = matchMedia("(prefers-reduced-motion: reduce)");
  function savedMotion() {
    try {
      return localStorage.getItem("eren-motion");
    } catch {
      return null;
    }
  }
  function applyMotion(paused) {
    document.documentElement.dataset.motion = paused ? "paused" : "running";
  }
  window.portfolio = {
    initialize() {
      const paused = savedMotion() === "paused" || reducedMotion.matches;
      applyMotion(paused);
      reducedMotion.addEventListener("change", (event) =>
        applyMotion(event.matches || savedMotion() === "paused"),
      );
      const dialog = document.getElementById("project-dialog");
      dialog.addEventListener("close", () => {
        document.body.style.overflow = "";
        if (previousFocus?.isConnected)
          previousFocus.focus({ preventScroll: true });
      });
      dialog.addEventListener("click", (event) => {
        const box = dialog.getBoundingClientRect();
        if (
          event.target === dialog &&
          (event.clientX < box.left ||
            event.clientX > box.right ||
            event.clientY < box.top ||
            event.clientY > box.bottom)
        )
          dialog.close();
      });
      const sections = document.querySelectorAll("main section[id]");
      const links = document.querySelectorAll(".nav-links a");
      const observer = new IntersectionObserver(
        (entries) => {
          for (const entry of entries) {
            if (!entry.isIntersecting) continue;
            links.forEach((link) => {
              if (link.hash === "#" + entry.target.id)
                link.setAttribute("aria-current", "location");
              else link.removeAttribute("aria-current");
            });
          }
        },
        { rootMargin: "-20% 0px -55% 0px" },
      );
      sections.forEach((section) => observer.observe(section));
      return paused;
    },
    setMotion(paused) {
      try {
        localStorage.setItem("eren-motion", paused ? "paused" : "running");
      } catch {
        /* Storage may be disabled. The control still works. */
      }
      applyMotion(paused);
    },
    openDialog(dialog) {
      previousFocus = document.activeElement;
      dialog.showModal();
      document.body.style.overflow = "hidden";
    },
    closeDialog(dialog) {
      dialog.close();
    },
    gameKeys(surface, active) {
      const existing = keyHandlers.get(surface);
      if (existing) surface.removeEventListener("keydown", existing);
      keyHandlers.delete(surface);
      if (active) {
        const handler = (event) => {
          if (["ArrowLeft", "ArrowRight"].includes(event.key))
            event.preventDefault();
        };
        surface.addEventListener("keydown", handler);
        keyHandlers.set(surface, handler);
      }
    },
    async chime(completed) {
      try {
        audioContext ??= new (window.AudioContext ||
          window.webkitAudioContext)();
        await audioContext.resume();
        const notes = completed ? [523, 659, 784, 1046] : [784, 1046];
        notes.forEach((frequency, index) => {
          const oscillator = audioContext.createOscillator();
          const gain = audioContext.createGain();
          const start = audioContext.currentTime + index * 0.075;
          oscillator.type = "square";
          oscillator.frequency.value = frequency;
          gain.gain.setValueAtTime(0.025, start);
          gain.gain.exponentialRampToValueAtTime(0.001, start + 0.13);
          oscillator.connect(gain);
          gain.connect(audioContext.destination);
          oscillator.start(start);
          oscillator.stop(start + 0.14);
        });
      } catch {
        /* Audio is optional and must never interrupt gameplay. */
      }
    },
  };
})();
