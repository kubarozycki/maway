export const SHOW_LOADER = "SHOW_LOADER";
export const HIDE_LOADER = "HIDE_LOADER";

export function showLoader() {
  return {
    type: SHOW_LOADER
  };
}

export const hideLoader = () => ({
  type: HIDE_LOADER
});